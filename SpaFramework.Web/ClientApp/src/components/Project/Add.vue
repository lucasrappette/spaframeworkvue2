<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <project-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Add Project</template>
    </project-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "ProjectAdd",
  mixins: [FormMixin],
  props: [],
  data() {
    return {
      item: {
        name: null
      }
    };
  },
  computed: {
    itemTitle: function () {
      if (this.item && this.item.name)
        return this.item.name;
      else
        return null;
    },
    pageTitle: function () {
      return 'New Project' + (this.itemTitle && this.itemTitle.length > 0 ? ': ' + this.itemTitle : '');
    }
  },
  methods: {
    load: function () {
      this.$store.dispatch('cachedData/loadClients');

      axios
        .get('/api/project/new')
        .then(response => {
          this.item = response.data;

          if (this.item.clientId)
            this.item.clientId = this.clientId;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Project');
        });
    },
    onCancel(evt) {
      this.goToParentPage();
    },
    onSubmit(evt) {
      let url = '/api/project';

      axios
        .post(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'Project');

          this.$store.dispatch('cachedData/reloadProjects');
          
          this.goToParentPage();
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Project');
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