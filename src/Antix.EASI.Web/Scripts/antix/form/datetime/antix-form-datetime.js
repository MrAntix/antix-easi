'use strict';

angular.module('antix.form.datetime', ['ui.bootstrap'])
    .directive(
        'aDatetime', [
            '$log',
            function ($log) {

                return {
                    restrict: 'AE',
                    replace: true,
                    scope: {
                        model: '=ngModel',
                        required: '=ngRequired',
                        format: '@'
                    },
                    require: ['ngModel'],
                    templateUrl: '/Scripts/antix/form/datetime/antix-form-datetime.html',
                    link: function (scope, element, attrs) {

                        scope.options = {
                            showWeeks: false,
                            showButtonBar: false
                        };

                        scope.opened = false;
                        scope.toggle = function ($event) {
                            $log.debug('aDatetime.toggle()');

                            scope.opened = !scope.opened;

                            $event.preventDefault();
                            $event.stopPropagation();
                        };
                    }
                };
            }
        ]);

