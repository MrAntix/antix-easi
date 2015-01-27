'use strict';

angular.module('antix.easi.examinations.index', [
        'antix.easi.examinations.list',
        'antix.easi.examinations.api'
    ])
    .controller(
        'AntixEASIExaminationsIndexController',
        [
            '$log', '$scope',
            'ExaminationsApi', 'SearchBoxEvents',
            function(
                $log, $scope,
                ExaminationsApi, SearchBoxEvents) {

                $log.debug('AntixEASIExaminationsIndexController init');

                var search = function (e, criteria) {

                    criteria = criteria || {};
                    $log.debug('AntixEASIExaminationsIndexController search(' + JSON.stringify(criteria) + ")");

                    ExaminationsApi.lookup({
                            text: criteria.text
                        }).$promise
                        .then(function(data) {
                            $scope.examinations = data;
                        });
                };

                search();

                $scope.$root.$on(SearchBoxEvents.Search, search);
            }
        ]);