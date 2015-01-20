'use strict';

angular.module('antix.easi.examiners.select', [
        'antix.easi.examiners.api'
])
    .directive(
        'examinersSelect',
        [
            '$log',
            'ExaminersApi',
            function (
                $log,
                ExaminersApi) {

                $log.debug('examinersSelect init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examiners/select/examiners-select.cshtml',
                    scope: {
                        'examiner': '='
                    },
                    link: function($scope, element, attrs) {
                        $log.debug('examinersSelect link');

                        $scope.get = function(filter) {
                            return ExaminersApi.lookup({
                                    filter: filter,
                                    limitTo: 8
                                }).$promise
                                .then(function(data) {
                                    $log.debug('examinersSelect lookup ' + JSON.stringify(data));

                                    return data;
                                });
                        }
                    }
                };
            }
        ]);