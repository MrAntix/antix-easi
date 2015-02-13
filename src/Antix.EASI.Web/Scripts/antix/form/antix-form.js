'use strict';

angular.module('antix.form', [
    'ui.bootstrap',
    'antix.form.datetime',
    'antix.form.confirm',
    'antix.form.clearButton',
    'ngSanitize'
]).filter('textToHtml', [
    '$sce',
    function ($sce) {
        return function (text) {
            if (!text) return '';

            var html = '';
            angular.forEach(text.split("\n\n"),
                function (textPart) {
                    html += '<p>' + textPart + '</p>';
                });

            return $sce.trustAsHtml(html);
        };
    }
]);
