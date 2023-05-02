<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <client-contact-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Save Client Contact</template>
    </client-contact-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';
import { mapState, mapGetters, mapMutations, mapActions } from 'vuex'

export default {
  name: "ClientContactEdit",
  mixins: [FormMixin],
  props: ['id'],
  data() {
    return {
      item: null
    };
  },
  computed: {
    itemTitle: function () {
      return null
    },
    pageTitle: function () {
      return 'Edit Client Contact';
    }
  },
  methods: {
    ...mapActions('cachedData', ['setKnownPageName']),
    load: function () {
      let url = '/api/clientContact/' + this.id;

      axios
        .get(url)
        .then(response => {
          this.item = response.data;

          this.setKnownPageName({ path: this.$route.path, name: this.item.region});
        })
        .catch(error => {
          console.log(error);
        });
    },
    onCancel(evt) {
      this.goToParentPage();
    },
    onSubmit(evt) {
      let url = '/api/clientContact/' + this.id;

      axios
        .put(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processEditSuccessResponse(response, 'Client Contact');

          this.goToParentPage();
        })
        .catch(error => {
          this.processEditErrorResponse(error, 'Client Contact');
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