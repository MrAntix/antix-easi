'use strict';

angular.module('antix.easi.clinicians.index', [
        'antix.easi.clinicians.list',
        'antix.easi.clinicians.api'
    ])
    .controller(
        'AntixEASICliniciansIndexController',
        [
            '$log', '$scope',
            'CliniciansApi', 'SearchBoxEvents',
            function(
                $log, $scope,
                CliniciansApi, SearchBoxEvents) {

                $log.debug('AntixEASICliniciansIndexController init');

                var search = function (e, criteria) {

                    criteria = criteria || {};
                    $log.debug('AntixEASICliniciansIndexController search(' + JSON.stringify(criteria) + ")");

                    CliniciansApi.lookup({
                            text: criteria.text
                        }).$promise
                        .then(function(data) {
                            $scope.clinicians = data;
                        });
                };

                search();

                $scope.$root.$on(SearchBoxEvents.Search, search);
            }
        ]);