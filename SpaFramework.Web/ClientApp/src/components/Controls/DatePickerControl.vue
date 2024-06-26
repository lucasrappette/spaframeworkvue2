<template>
  <b-form-group :label="label" :description="description" :invalid-feedback="validationError" class="form-floating-label-group">
  <!-- <b-form-group :label="label" :description="description" :invalid-feedback="validationError" label-cols="4" content-cols="8"> -->
    <small v-if="topDescription" class="text-muted">{{topDescription}}</small>
    <b-input-group>
      <b-form-input v-model="textContent" @input="event => transformTextInputAndUpdate(event)" :state="state" placeholder="MM/DD/YYYY" autocomplete="off" class="floating-label" />
      <b-input-group-append>
        <b-form-datepicker v-model="content" button-only right @input="event => transformDateInputAndUpdate(event)" :type="type" :date-info-fn="dateInfoFunction" :date-disabled-fn="dateDisabledFunction"></b-form-datepicker>
      </b-input-group-append>
    </b-input-group>
  </b-form-group>
</template>

<script>
import { DateTime } from 'luxon';
export default {
  name: "DatePickerControl",
  props: {
    label: {},
    description: {},
    topDescription: {},
    value: {
      required: true
    },
    type: {
      default: 'text'
    },
    required: {
      default: false
    },
    requiredError: {
      default: 'This field is required'
    },
    customValidation: {},
    formName: {
      default: 'Default'
    },
    dateInfoFunction: {
      default: (ymd, date) => { return null; }
    },
    dateDisabledFunction: {
      default: null//(ymd, date) => { return false; }
    },
    concurrencyCheck: {
      default: null
    }
  },
  data() {
    return {
      textContent: this.value ? DateTime.fromISO(this.value).toLocaleString('en-US') : null,
      content: this.value,
      originalValue: this.value,
      state: null,
      validationError: null
    };
  },
  computed: {
    isValid: function () {
      if (this.state === null)
        this.checkValidity(this.content, this.content);

      return this.state === true || this.state === null;
    }
  },
  methods: {
    onFormat(value, e) {
      if (!e.data)
        return value;

      if (isNaN(parseInt(e.data)) && value.endsWith(e.data))
        return value.substring(0, value.length - 1);

      if (value.length == 2)
        value += '/';
      else if (value.length == 5)
        value += '/';
      else if (value.length > 10)
        value = value.substring(0, 10);

      return value;
    },
    transformTextInputAndUpdate(newValue) {
      var d = DateTime.fromFormat(newValue, 'M/d/yyyy')
      this.content = d.toISO();
      this.checkValidity(this.content);
      this.$emit('input', this.content);
    },
    transformDateInputAndUpdate(newValue) {
      var d = DateTime.fromISO(newValue);
      this.textContent = d.toLocaleString('en-US');
      this.content = newValue;
      this.$emit('input', this.content);
    },
    isValidDate(dateString) {
      var regEx = /^((\d{4}-\d{2}-\d{2})+(T(00|:)+)*(\.\d{3}-\d{2}:\d{2})*)$/;
      if(typeof dateString !== 'string')
        return false;
      // Invalid format
      if (!dateString.match(regEx))
        return false;

      var d = new Date(dateString);
      var dNum = d.getTime();

      // NaN value, Invalid date
      if (!dNum && dNum !== 0)
        return false;

      return true;
    },
    checkValidity(newValue, oldValue) {
      let validationError = null;

      // if (!this.isValidDate(newValue))
      //   validationError = 'Please enter a valid date';
      //else 
      if (this.required !== null && this.required !== false && (newValue == null || newValue == '' || !this.isValidDate(newValue)))
        validationError = this.requiredError;
      else if (typeof(this.customValidation) === 'function') {
        let retVal = this.customValidation(newValue, oldValue);
        if (retVal !== true && retVal !== null)
          validationError = retVal;
        else {
          this.state = retVal;
          validationError = null;
        }
      }

      this.validationError = validationError;
      if (this.validationError != null)
        this.state = false;
      else {
        if (this.originalValue == newValue)
          this.state = null;
        else
          this.state = true;
      }
    }
  },
  watch: {
    content: function (newValue, oldValue) {
      this.checkValidity(newValue, oldValue);
    },
    concurrencyCheck: function (newValue, oldValue) {
      this.originalValue = this.content;
      this.state = null;
    }
  },
  mounted () {
  }
};
</script>