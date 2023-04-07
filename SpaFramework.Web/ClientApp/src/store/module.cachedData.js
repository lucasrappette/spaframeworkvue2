import Vue from 'vue';
import Vuex from 'vuex';
import axios from "axios";

const STATE_UNLOADED = 0;
const STATE_LOADING = 1;
const STATE_LOADED = 2;

export default {
  namespaced: true,
  state: () => ({
    knownPageNames: [
      { path: '/', name: 'Home' },
      { path: '/add', name: 'Add New' },
      { path: '/content', name: 'Content' },
      { path: '/summary', name: 'Summary' },

      { path: '/client', name: 'Clients' },
      { path: '/project', name: 'Projects' },
      { path: '/applicationUser', name: 'Users' },
      { path: '/contentBlock', name: 'Content Blocks' },
      { path: '/job', name: 'Background Jobs' },
    ],
    stateSelectOptions: [
      { text: "", value: null },
      { text: "Alabama", value: "AL" },
      { text: "Alaska", value: "AK" },
      { text: "Alberta", value: "AB" },
      { text: "American Samoa", value: "AS" },
      { text: "Arizona", value: "AZ" },
      { text: "Arkansas", value: "AR" },
      { text: "British Columbia", value: "BC" },
      { text: "California", value: "CA" },
      { text: "Colorado", value: "CO" },
      { text: "Connecticut", value: "CT" },
      { text: "Delaware", value: "DE" },
      { text: "District Of Columbia", value: "DC" },
      { text: "Federated States Of Micronesia", value: "FM" },
      { text: "Florida", value: "FL" },
      { text: "Georgia", value: "GA" },
      { text: "Guam", value: "GU" },
      { text: "Hawaii", value: "HI" },
      { text: "Idaho", value: "ID" },
      { text: "Illinois", value: "IL" },
      { text: "Indiana", value: "IN" },
      { text: "Iowa", value: "IA" },
      { text: "Kansas", value: "KS" },
      { text: "Kentucky", value: "KY" },
      { text: "Louisiana", value: "LA" },
      { text: "Maine", value: "ME" },
      { text: "Manitoba", value: "MB" },
      { text: "Marshall Islands", value: "MH" },
      { text: "Maryland", value: "MD" },
      { text: "Massachusetts", value: "MA" },
      { text: "Michigan", value: "MI" },
      { text: "Minnesota", value: "MN" },
      { text: "Mississippi", value: "MS" },
      { text: "Missouri", value: "MO" },
      { text: "Montana", value: "MT" },
      { text: "Nebraska", value: "NE" },
      { text: "Nevada", value: "NV" },
      { text: "New Brunswick", value: "NB" },
      { text: "New Hampshire", value: "NH" },
      { text: "New Jersey", value: "NJ" },
      { text: "New Mexico", value: "NM" },
      { text: "New York", value: "NY" },
      { text: "Newfoundland and Labrador", value: "NL" },
      { text: "North Carolina", value: "NC" },
      { text: "North Dakota", value: "ND" },
      { text: "Northern Mariana Islands", value: "MP" },
      { text: "Northwest Territories", value: "NT" },
      { text: "Nova Scotia", value: "NS" },
      { text: "Nunavut", value: "NU" },
      { text: "Ohio", value: "OH" },
      { text: "Oklahoma", value: "OK" },
      { text: "Ontario", value: "ON" },
      { text: "Oregon", value: "OR" },
      { text: "Palau", value: "PW" },
      { text: "Pennsylvania", value: "PA" },
      { text: "Prince Edward Island", value: "PE" },
      { text: "Puerto Rico", value: "PR" },
      { text: "Quebec", value: "QC" },
      { text: "Rhode Island", value: "RI" },
      { text: "Saskatchewan", value: "SK" },
      { text: "South Carolina", value: "SC" },
      { text: "South Dakota", value: "SD" },
      { text: "Tennessee", value: "TN" },
      { text: "Texas", value: "TX" },
      { text: "Utah", value: "UT" },
      { text: "Vermont", value: "VT" },
      { text: "Virgin Islands", value: "VI" },
      { text: "Virginia", value: "VA" },
      { text: "Washington", value: "WA" },
      { text: "West Virginia", value: "WV" },
      { text: "Wisconsin", value: "WI" },
      { text: "Wyoming", value: "WY" },
      { text: "Yukon", value: "YT" },
    ],
    projectStateSelectOptions: [
      {
        text: '',
        value: null
      },
      {
        text: 'Open',
        value: 'Open'
      },
      {
        text: 'On Hold',
        value: 'OnHold'
      },
      {
        text: 'Closed',
        value: 'Closed'
      }
    ],
    applicationRoles: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    clients: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    projects: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
  }),
  mutations: {
    SET_KNOWN_PAGE_NAME(state, item) {
      let existing = state.knownPageNames.find(x => x.path == item.path);

      if (existing)
        existing.name = item.name;
      else
        state.knownPageNames.push({
          path: item.path,
          name: item.name
        });
    },
    ADD_PENDING_PROMISE(state, data) {
      state[data.type].pendingResolves.push(data.resolve);
      state[data.type].pendingRejects.push(data.reject);
    },
    CLEAR_PENDING_PROMISES(state, data) {
      state[data.type].pendingResolves.length = 0;
      state[data.type].pendingRejects.length = 0;
    },
    SET_LOAD_STATE(state, data) {
      state[data.type].loadState = data.loadState;
    },
    LOAD_APPLICATION_ROLES(state, values) {
      state.applicationRoles.values = values;

      state.applicationRoles.selectOptions = values.map(x => ({
        text: x.name,
        value: x.id,
        sortOrder: x.sortOrder,
        description: x.description
      }));

      state.applicationRoles.selectOptions.unshift({
        text: '',
        value: null
      });

      state.applicationRoles.loadState = STATE_LOADED;
    },
    LOAD_CLIENTS(state, values) {
      state.clients.values = values;

      state.clients.selectOptions = values.map(x => ({
        text: x.abbreviation + ' (' + x.name + ')',
        value: x.id
      }));

      state.clients.selectOptions.unshift({
        text: '',
        value: null
      });

      state.clients.loadState = STATE_LOADED;
    },
    LOAD_PROJECTS(state, values) {
      state.projects.values = values;

      state.projects.selectOptions = values.map(x => ({
        text: x.name,
        value: x.id
      }));

      state.projects.selectOptions.unshift({
        text: '',
        value: null
      });

      state.projects.loadState = STATE_LOADED;
    },
  },
  actions: {
    setKnownPageName({ state, commit }, item) {
      commit('SET_KNOWN_PAGE_NAME', item);
    },
    loadValues({ state, commit, rootState }, valType) {
      return new Promise((resolve, reject) => {
        if (state[valType.type].loadState == STATE_LOADED)
        {
          resolve();
          return;
        }

        if (state[valType.type].loadState == STATE_LOADING) {
          commit('ADD_PENDING_PROMISE', {
            type: valType.type,
            resolve: resolve,
            reject: reject
          });

          return;
        }

        commit('SET_LOAD_STATE', {
          type: valType.type,
          loadState: STATE_LOADING
        });
        //commit('SET_' + valType.commitType + '_LOAD_STATE', STATE_LOADING);

        let url = valType.url;
        url += '?limit=1000';

        if (valType.includes && valType.includes.length > 0)
          url += '&includes=' + valType.includes.join(',')

        if (valType.order)
          url += '&order=' + encodeURIComponent(valType.order);

        if (valType.filter)
          url += '&filter=' + encodeURIComponent(valType.filter);
        axios
          .get(url)
          .then(response => {
            commit('LOAD_' + valType.commitType, response.data);
            resolve();
            if (state[valType.type].pendingResolves) {
              state[valType.type].pendingResolves.forEach(function (callback) {
                callback();
              });
            }

            commit('CLEAR_PENDING_PROMISES', {
              type: valType.type,
            });
          })
          .catch(error => {
            console.log(error);

            reject();
            if (state[valType.type].pendingRejects) {
              state[valType.type].pendingRejects.forEach(function (callback) {
                callback();
              });
            }

            commit('CLEAR_PENDING_PROMISES', {
              type: valType.type,
            });
          });
      });
    },
    loadApplicationRoles({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'applicationRoles', 
        commitType: 'APPLICATION_ROLES', 
        url: '/api/applicationRole'
      });
    },
    reloadApplicationRoles({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'applicationRoles',
        loadState: STATE_UNLOADED
      });
      dispatch('loadApplicationRoles');
    },
    loadClients({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'clients', 
        commitType: 'CLIENTS', 
        url: '/api/client',
        order: 'name'
      });
    },
    reloadClients({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'clients',
        loadState: STATE_UNLOADED
      });
      dispatch('loadClients');
    },
    loadProjects({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'projects', 
        commitType: 'PROJECTS', 
        url: '/api/project',
        order: 'name',
        includes: ['client']
      });
    },
    reloadProjects({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'projects',
        loadState: STATE_UNLOADED
      });
      dispatch('loadProjects');
    },
    loadCachedData({ commit, dispatch }) {
      dispatch('loadProjects');
      dispatch('loadClients');
      dispatch('loadApplicationRoles');
    },
    reloadCachedData({ commit, dispatch }) {
      dispatch('reloadProjects');
      dispatch('reloadClients');
      dispatch('reloadApplicationRoles');
    }
  },
  getters: {
  }
}