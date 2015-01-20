'use strict';

angular.module('antix.easi.examiners.index', [
        'antix.easi.examiners.list',
        'antix.easi.examiners.api'
    ])
    .controller(
        'AntixEASIExaminersIndexController',
        [
            '$log', '$scope',
            'ExaminersApi', 'SearchBoxEvents',
            function(
                $log, $scope,
                ExaminersApi, SearchBoxEvents) {

                $log.debug('AntixEASIExaminersIndexController init');

                var search = function (e, criteria) {

                    criteria = criteria || {};
                    $log.debug('AntixEASIExaminersIndexController search(' + JSON.stringify(criteria) + ")");

                    ExaminersApi.lookup({
                            text: criteria.text
                        }).$promise
                        .then(function(data) {
                            $scope.examiners = data;
                        });
                };

                search();

                $scope.$root.$on(SearchBoxEvents.Search, search);
            }
        ]);