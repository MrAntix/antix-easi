'use strict';

angular.module('antix.easi.clinicians.select', [
        'antix.easi.clinicians.api'
])
    .directive(
        'cliniciansSelect',
        [
            '$log',
            'CliniciansApi',
            function (
                $log,
                CliniciansApi) {

                $log.debug('cliniciansSelect init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'clinicians/select/clinicians-select.cshtml',
                    scope: {
                        'clinician': '='
                    },
                    link: function($scope, element, attrs) {
                        $log.debug('cliniciansSelect link');

                        $scope.get = function(filter) {
                            return CliniciansApi.lookup({
                                    filter: filter,
                                    limitTo: 8
                                }).$promise
                                .then(function(data) {
                                    $log.debug('cliniciansSelect lookup ' + JSON.stringify(data));

                                    return data;
                                });
                        }
                    }
                };
            }
        ]);