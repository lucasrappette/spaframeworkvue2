<template>
  <div>
    <list-page-template page-title="Client Contacts">
      <filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
      </filtered-table>
    </list-page-template>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ClientContactList",
  props: ['clientId'],
  data() {
    return {
      tableSettings: {
        endpoint: '/api/clientContact',
        showNewButton: true,
        defaultLimit: 100,
        columns: [
          {
            key: 'id',
            name: 'ID',
            visible: false,
            sortable: true,
            type: 'guid'
          },
          {
            key: 'firstName',
            name: 'First Name',
            visible: true,
            sortable: true,
            type: 'text'
          },
        ],
        getDefaultFilter: () => {
          if (this.clientId)
            return 'clientId="' + this.clientId + '"';

          return '';
        },
        includes: [],
        viewStorageName: '/client:clientContact'
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