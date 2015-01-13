'use strict';

angular.module('antix.easi.clinicians.select', [
        'antix.easi.clinicians.api'
    ])
    .directive(
        'cliniciansSelect',
        [
            '$log',
            'CliniciansApi',
            function(
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

                        CliniciansApi.lookup().$promise
                            .then(function(data) {
                                $log.debug('cliniciansSelect lookup ' + JSON.stringify(data));

                                $scope.clinicians = data;
                            });
                    }
                }
            }
        ]);