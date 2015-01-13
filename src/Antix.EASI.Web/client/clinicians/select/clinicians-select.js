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
                        'id': '='
                    },
                    link: function($scope, element, attrs) {
                        $log.debug('cliniciansSelect link');

                        CliniciansApi.lookup().$promise
                            .then(function(data) {
                                $log.debug('cliniciansSelect lookup ' + JSON.stringify(data));

                                $scope.clinicians = data;
                            });

                        var firstById = function(id) {
                            for(var i=0; i<$scope.clinicians.length;i++)
                                if ($scope.clinicians[i].id === id) return $scope.clinicians[i];
                            return null;
                        };

                        $scope.select = function(id) {
                            $scope.id = id;
                            $scope.name = firstById(id).name;
                        };
                    }
                }
            }
        ]);