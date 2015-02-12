'use strict';

angular.module('antix.easi.home', [
        'antix.calendar',
        'antix.easi.examinations.list',
        'antix.easi.examinations.api'
])
    .controller(
        'AntixEASIHomeController',
        [
            '$log', '$scope', '$state', '$filter',
            'ExaminationsApi', 'SearchBoxEvents',
            'AntixCalendarEvents',
            function (
                $log, $scope, $state, $filter,
                ExaminationsApi, SearchBoxEvents,
                AntixCalendarEvents) {

                $log.debug('AntixEASIHomeController init');

                var search = function (e, criteria) {

                    criteria = criteria || {};
                    $log.debug('AntixEASIHomeController search(' + JSON.stringify(criteria) + ")");

                    ExaminationsApi.search({
                        text: criteria.text,
                        dateFrom: criteria.dateFrom,
                        dateTo: criteria.dateTo,
                        count: 10
                    }).$promise
                        .then(function (response) {
                            $scope.examinations = response.items;

                            if (criteria.dateFrom) {
                                $scope.searchTitle = "From " + $filter('date')(criteria.dateFrom, 'mediumDate');

                                if (criteria.dateTo) {
                                    $scope.searchTitle = " to " + $filter('date')(criteria.dateTo, 'mediumDate');

                                }
                            } else if (criteria.text) {
                                $scope.searchTitle = "Searched for '" + criteria.text + "'";
                            }

                            $scope.searchTitle = $scope.searchTitle + " <small>found " + response.totalCount + "</found>";
                        });
                };

                $scope.$root.$on(SearchBoxEvents.Search, search);
                $scope.$root.$on(AntixCalendarEvents.Selected, function (e, data) {
                    search(e, {
                        dateFrom: data.dateFrom,
                        //dateTo: data.dateTo
                    });
                });

                $scope.selectedDate = new Date();
            }
        ]);