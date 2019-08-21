﻿// to fix jQuery dat format 'en-GB' validation problem
// in chrome

$(function () {
    $.validator.addMethod(
        "date",
        function (value, element) {
            var bits = value.match(/([0-9]+)/gi), str;
            if (!bits)
                return this.optional(element) || false;
            str = bits[1] + '/' + bits[0] + '/' + bits[2];
            return this.optional(element) || !/Invalid|Nan/.test(new Date(str));
        },
        "Please enter date in valid format [dd/mm/yyyy]"
    );
});