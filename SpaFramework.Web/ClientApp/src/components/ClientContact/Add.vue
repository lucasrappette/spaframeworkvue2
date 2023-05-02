<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <client-contact-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Add Client Contact</template>
    </client-contact-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "ClientContactAdd",
  mixins: [FormMixin],
  props: ['clientId'],
  data() {
    return {
      item: null
    };
  },
  computed: {
    itemTitle: function () {
        return null;
    },
    pageTitle: function () {
      return 'New Client Contact' + (this.itemTitle && this.itemTitle.length > 0 ? ': ' + this.itemTitle : '');
    }
  },
  methods: {
    load: function () {
      axios
        .get('/api/clientContact/new')
        .then(response => {
          this.item = response.data;

          if (this.clientId)
            this.item.clientId = this.clientId;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Client Contact');
        });
    },
    onCancel(evt) {
      this.goToParentPage();
    },
    onSubmit(evt) {
      let url = '/api/clientContact';

      axios
        .post(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'Client Contact');
          
          this.goToParentPage();
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Client Contact');
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