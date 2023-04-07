<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <b-nav pills v-if="item">
      <b-nav-item :to="{ path: this.$route.path + '/campaign' }">Campaigns</b-nav-item>
      <b-nav-item :to="{ path: this.$route.path + '/project' }">Projects</b-nav-item>
      <b-nav-item :to="{ path: this.$route.path + '/disposition' }">Dispositions</b-nav-item>
    </b-nav>
    <hr />
    <client-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Save Client</template>
    </client-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';
import { mapState, mapGetters, mapMutations, mapActions } from 'vuex'

export default {
  name: "ClientEdit",
  mixins: [FormMixin],
  props: ['id'],
  data() {
    return {
      item: null
    };
  },
  computed: {
    itemTitle: function () {
      if (!this.item)
        return null;
      return this.item.name;
    },
    pageTitle: function () {
      return 'Client: ' + this.itemTitle;
    }
  },
  methods: {
    ...mapActions('cachedData', ['setKnownPageName']),
    load: function () {
      let url = '/api/client/' + this.id + '?context=WebApiElevated';

      axios
        .get(url)
        .then(response => {
          this.item = response.data;

          this.setKnownPageName({ path: this.$route.path, name: this.item.name});
        })
        .catch(error => {
          console.log(error);
        });
    },
    onCancel(evt) {
      this.goToParentPage();
    },
    onSubmit(evt) {
      let url = '/api/client/' + this.id + '?context=WebApiElevated';

      axios
        .put(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processEditSuccessResponse(response, 'Client');

          this.goToParentPage();
        })
        .catch(error => {
          this.processEditErrorResponse(error, 'Client');
        });
    }
  },
  mounted () {
    this.load();
    // Use this instead of the previous line to test the "Loading" bar
    //window.setTimeout(this.load, 3000);
  }
};
</script>