'use strict';

angular.module('antix.easi.home', [
        'antix.calendar',
        'antix.easi.examinations.list',
        'antix.easi.examinations.api'
])
    .controller(
        'AntixEASIHomeController',
        [
            '$log', '$scope', '$state',
            'ExaminationsApi', 'SearchBoxEvents',
            'AntixCalendarEvents',
            function (
                $log, $scope, $state,
                ExaminationsApi, SearchBoxEvents,
                AntixCalendarEvents) {

                $log.debug('AntixEASIHomeController init');

                var search = function (e, criteria) {

                    criteria = criteria || {};
                    $log.debug('AntixEASIHomeController search(' + JSON.stringify(criteria) + ")");

                    ExaminationsApi.lookup({
                        text: criteria.text,
                        dateFrom: criteria.dateFrom,
                        dateTo: criteria.dateTo
                    }).$promise
                        .then(function (data) {
                            $scope.examinations = data;
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