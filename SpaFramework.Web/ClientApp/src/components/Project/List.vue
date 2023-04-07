<template>
  <list-page-template page-title="Projects">
    <filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
    </filtered-table>
  </list-page-template>
</template>

<script>
import axios from "axios";

export default {
  name: "ProjectList",
  props: {},
  data() {
    let base = this;
    return {
      tableSettings: {
        endpoint: '/api/project',
        showNewButton: true,
        columns: [
          {
            key: 'id',
            name: 'ID',
            visible: false,
            sortable: true,
            type: 'guid'
          },
          {
            key: 'name',
            name: 'Name',
            visible: true,
            sortable: true,
            type: 'text',
            filterMethod: 'contains'
          },
          {
            key: 'clientId',
            name: 'Client',
            visible: true,
            sortable: true,
            type: 'select',
            selectOptionsSource: { storeModule: 'cachedData', storeAction: 'loadClients', storeGetter: 'clients' }
          },
          {
            key: 'client.abbreviation',
            name: 'Client Abbreviation',
            visible: true,
            sortable: false,
            type: 'text'
          },
          {
            key: 'state',
            name: 'State',
            visible: true,
            sortable: true,
            type: 'select',
            selectOptionsSource: { storeModule: 'cachedData', storeGetter: 'projectStateSelectOptions' }
          },
          {
            key: 'startDate',
            name: 'Start Date',
            visible: true,
            sortable: true,
            type: 'date'
          },
          {
            key: 'endDate',
            name: 'End Date',
            visible: true,
            sortable: true,
            type: 'date'
          },
          {
            key: 'lastModification',
            name: 'Last Modification',
            visible: false,
            sortable: true,
            type: 'date'
          }
        ],
        getDefaultFilter: function () {
          return '';
        },
        includes: ['client'],
        viewStorageName: '/client:project'
      }
    }
  },
  methods: {
    onRowClicked: function (item, context) {
      this.$router.push(this.$route.path + '/' + item.id);
    },
    onNewClicked: function (filters) {
      this.$router.push(this.$route.path + '/add');
    },
  },
  computed: {
  },
  mounted () {
  }
};
</script>