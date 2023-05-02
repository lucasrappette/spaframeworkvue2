<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="6" lg="3">
          <h4>Client Contact</h4>
          <hr />
          <text-control label="First Name" required v-model="item.firstName" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Last Name" required v-model="item.lastName" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Telephone" required v-model="item.phoneNumber" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Email" required v-model="item.email" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Title" required v-model="item.title" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Description" required v-model="item.description" :concurrency-check="item.concurrencyCheck"></text-control>
          <checkbox-control label="IsActive" v-model="item.isActive" :concurrency-check="item.concurrencyCheck"></checkbox-control>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'

export default {
  name: "ClientContactFields",
  props: [
    'item'
  ],
  data() {
    return {
    };
  },
  computed: {

  },
  methods: {
    load() {
    },
    onCancel(evt) {
      this.$emit('cancel');
    },
    onSubmit(evt) {
      this.$emit('submit');
    }
  },
  mounted() {
    this.load();
  }
};
</script>