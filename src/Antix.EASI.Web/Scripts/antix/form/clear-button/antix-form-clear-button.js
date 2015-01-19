'use strict';

angular.module('antix.form.clearButton', [])
    .directive(
        'aClearButton', [
            '$log',
            function (
                $log) {

                return {
                    restrict: 'A',
                    replace: false,
                    link: function ($scope, element) {

                        var button = angular
                            .element('<span class="clear-button">&times;</span>')
                            .on('click', function () {
                                element.val('').triggerHandler('change');
                                button.css({ display: 'none' });
                            });

                        element
                            .after(button)
                        .addClass('has-clear-button');

                        $scope.$watch(function () {
                            return element.val();
                        }, function (value) {
                            $log.debug(value);

                            button.css({ display: value ? '' : 'none' });
                        });

                    }
                };
            }
        ]);

