// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


// cef_value

// CEF_EXPORT cef_value_t* cef_value_create();
static cef_value_t* cfx_value_create() {
    return cef_value_create();
}
// is_valid
static int cfx_value_is_valid(cef_value_t* self) {
    return self->is_valid(self);
}

// is_owned
static int cfx_value_is_owned(cef_value_t* self) {
    return self->is_owned(self);
}

// is_read_only
static int cfx_value_is_read_only(cef_value_t* self) {
    return self->is_read_only(self);
}

// is_same
static int cfx_value_is_same(cef_value_t* self, cef_value_t* that) {
    if(that) ((cef_base_t*)that)->add_ref((cef_base_t*)that);
    return self->is_same(self, that);
}

// is_equal
static int cfx_value_is_equal(cef_value_t* self, cef_value_t* that) {
    if(that) ((cef_base_t*)that)->add_ref((cef_base_t*)that);
    return self->is_equal(self, that);
}

// copy
static cef_value_t* cfx_value_copy(cef_value_t* self) {
    return self->copy(self);
}

// get_type
static cef_value_type_t cfx_value_get_type(cef_value_t* self) {
    return self->get_type(self);
}

// get_bool
static int cfx_value_get_bool(cef_value_t* self) {
    return self->get_bool(self);
}

// get_int
static int cfx_value_get_int(cef_value_t* self) {
    return self->get_int(self);
}

// get_double
static double cfx_value_get_double(cef_value_t* self) {
    return self->get_double(self);
}

// get_string
static cef_string_userfree_t cfx_value_get_string(cef_value_t* self) {
    return self->get_string(self);
}

// get_binary
static cef_binary_value_t* cfx_value_get_binary(cef_value_t* self) {
    return self->get_binary(self);
}

// get_dictionary
static cef_dictionary_value_t* cfx_value_get_dictionary(cef_value_t* self) {
    return self->get_dictionary(self);
}

// get_list
static cef_list_value_t* cfx_value_get_list(cef_value_t* self) {
    return self->get_list(self);
}

// set_null
static int cfx_value_set_null(cef_value_t* self) {
    return self->set_null(self);
}

// set_bool
static int cfx_value_set_bool(cef_value_t* self, int value) {
    return self->set_bool(self, value);
}

// set_int
static int cfx_value_set_int(cef_value_t* self, int value) {
    return self->set_int(self, value);
}

// set_double
static int cfx_value_set_double(cef_value_t* self, double value) {
    return self->set_double(self, value);
}

// set_string
static int cfx_value_set_string(cef_value_t* self, char16 *value_str, int value_length) {
    cef_string_t value = { value_str, value_length, 0 };
    return self->set_string(self, &value);
}

// set_binary
static int cfx_value_set_binary(cef_value_t* self, cef_binary_value_t* value) {
    if(value) ((cef_base_t*)value)->add_ref((cef_base_t*)value);
    return self->set_binary(self, value);
}

// set_dictionary
static int cfx_value_set_dictionary(cef_value_t* self, cef_dictionary_value_t* value) {
    if(value) ((cef_base_t*)value)->add_ref((cef_base_t*)value);
    return self->set_dictionary(self, value);
}

// set_list
static int cfx_value_set_list(cef_value_t* self, cef_list_value_t* value) {
    if(value) ((cef_base_t*)value)->add_ref((cef_base_t*)value);
    return self->set_list(self, value);
}


