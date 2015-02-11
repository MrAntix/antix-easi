'use strict';

angular.module('antix.calendar', [
        'antix.calendar.services'
])
    .directive('antixCalendar',
    [
        '$log', '$timeout', '$document',
        '$$rAF',
        'AntixCalendarService',
        function (
            $log, $timeout, $document,
            $$rAF,
            CalendarService) {

            $log.debug('antixCalendar.init');

            return {
                restrict: 'AE',
                replace: true,
                scope: true,
                templateUrl: '/scripts/antix/calendar/antix-calendar.html',
                link: function (scope, element) {

                    var container = document.body,
                        calendar = CalendarService.createCalendar(element, new Date()),
                        calendarInitialPadding = 5000,
                        calendarTopPadding = 0,
                        calendarBottomPadding = 0,
                        cellHeight = 40,
                        monthOffset = -36,
                        getMonthHeight = function (weeks) { return weeks * cellHeight + monthOffset; };

                    scope.months = calendar.months;

                    var load = function () {

                        scope.$apply(function () {

                            var watchers = scope.$$watchers;
                            scope.$$watchers = [];

                            var scrollTop = container.scrollTop,
                                containerHeight = container.offsetHeight,
                                elementHeight = element[0].offsetHeight - calendarTopPadding;

                            while (scrollTop - 300 < calendarTopPadding) {
                                calendar.min.add();

                                calendarTopPadding -= getMonthHeight(calendar.min.weeks);
                            }

                            var offset = elementHeight
                                + calendarTopPadding
                                - scrollTop;

                            while (offset
                                - calendarBottomPadding
                                - 300
                                < containerHeight) {
                                calendar.max.add();

                                calendarBottomPadding -=
                                    getMonthHeight(calendar.max.weeks);
                            }

                            while (scrollTop - 600 > calendarTopPadding) {

                                calendarTopPadding += getMonthHeight(calendar.min.weeks);

                                calendar.min.remove();
                            }

                            while (offset
                                - calendarBottomPadding
                                - 600
                                > containerHeight) {

                                calendarBottomPadding +=
                                    getMonthHeight(calendar.max.weeks);

                                calendar.max.remove();
                            }


                            element.css({
                                'padding-top': calendarTopPadding + 'px',
                                'padding-bottom': calendarBottomPadding + 'px'
                            });

                            scope.$$watchers = watchers;
                        });

                        $$rAF(load);
                    };

                    var resetId,
                        reset = function () {

                            var offset = container.scrollTop - calendarTopPadding;
                            calendarTopPadding = calendarInitialPadding;
                            calendarBottomPadding = calendarInitialPadding;

                            element.css({
                                'padding-top': calendarTopPadding + 'px',
                                'padding-bottom': calendarBottomPadding + 'px'
                            });

                            container.scrollTop = calendarTopPadding + offset;
                        };

                    var start = function () {
                        reset();
                        $$rAF(load);
                    };

                    start();

                    element.on('scroll', function () {
                        if (resetId) {
                            $timeout.cancel(resetId);
                            resetId = null;
                        }

                        resetId = $timeout(reset, 500);
                    });
                }
            }
        }
    ]);