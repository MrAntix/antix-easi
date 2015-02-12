'use strict';

angular.module('antix.calendar', [
        'antix.calendar.services'
])
    .directive('antixCalendar',
    [
        '$log', '$timeout', '$document',
        'AntixCalendarService',
        function (
            $log, $timeout, $document,
            CalendarService) {

            $log.debug('antixCalendar.init');

            return {
                restrict: 'AE',
                replace: true,
                scope: true,
                templateUrl: '/scripts/antix/calendar/antix-calendar.html',
                link: function (scope, element) {

                    var containerDom = $document.prop('body'),
                        calendar = CalendarService.createCalendar(element, new Date()),
                        calendarInitialPadding = 2000,
                        cellHeight = 40,
                        monthOffset = -36,
                        getMonthHeight = function (weeks) { return weeks * cellHeight + monthOffset; };

                    scope.months = calendar.months;

                    var reset = function () {
                        $log.debug('antixCalendar.reset()');

                        var watchers = scope.$$watchers;
                        scope.$$watchers = [];

                        var calendarTopPadding = calendarInitialPadding,
                            calendarBottomPadding = calendarInitialPadding,
                            scrollTop = containerDom.scrollTop,
                            containerHeight = window.innerHeight,
                            elementHeight = element[0].offsetHeight - calendarTopPadding;

                        while (scrollTop - 300 < calendarTopPadding) {
                            $log.debug('antixCalendar.min.add()');

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
                            $log.debug('antixCalendar.max.add()');

                            calendar.max.add();

                            calendarBottomPadding -=
                                getMonthHeight(calendar.max.weeks);
                        }

                        while (scrollTop - 600 > calendarTopPadding) {
                            $log.debug('antixCalendar.min.remove()');

                            calendarTopPadding += getMonthHeight(calendar.min.weeks);

                            calendar.min.remove();
                        }

                        while (offset
                            - calendarBottomPadding
                            - 600
                            > containerHeight) {
                            $log.debug('antixCalendar.max.remove()');

                            calendarBottomPadding +=
                                getMonthHeight(calendar.max.weeks);

                            calendar.max.remove();
                        }

                        scrollTop = calendarInitialPadding + scrollTop - calendarTopPadding;
                        if (containerDom.scrollTop !== scrollTop)
                            containerDom.scrollTop = scrollTop;

                        scope.$$watchers = watchers;
                    };

                    var resetId;

                    angular.element(window)
                        .on('scroll', function () {

                            if (resetId) {
                                $timeout.cancel(resetId);
                                resetId = null;
                            }

                            resetId = $timeout(function () {
                                scope.$evalAsync(reset);
                            }, 150);
                        });

                    scope.$evalAsync(reset);
                    $timeout(function () {
                        containerDom.scrollTop = calendarInitialPadding + 200;
                    });
                }
            }
        }
    ]);