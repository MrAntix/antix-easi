'use strict';

angular.module('antix.calendar.services', [
    ])
    .factory('AntixCalendarService',
    [
        '$log', 
        function(
            $log) {

            $log.debug('AntixCalendarService.init');

            var service = {
                createCalendar: function(element, date) {

                    var preload = 2,
                        calendar = {
                            months: service.createMonths(date, preload)
                        };

                    var getMin = function(d) {

                            d.add = function() {
                                calendar.min = getMin(
                                    service.getUTCDate(calendar.min.getUTCFullYear(), calendar.min.getUTCMonth() - 1, 1)
                                );

                                calendar.months.unshift(service.createMonth(calendar.min));
                            };

                            d.remove = function() {
                                calendar.min = getMin(
                                    service.getUTCDate(calendar.min.getUTCFullYear(), calendar.min.getUTCMonth() + 1, 1)
                                );

                                calendar.months.shift();
                            };
                            d.weeks = service.getWeeksInMonth(d);

                            return d;
                        },
                        getMax = function(d) {

                            d.add = function() {
                                calendar.max = getMax(
                                    service.getUTCDate(calendar.max.getUTCFullYear(), calendar.max.getUTCMonth() + 2, 0)
                                );

                                calendar.months.push(service.createMonth(calendar.max));
                            };

                            d.remove = function() {

                                calendar.max = getMax(
                                    service.getUTCDate(calendar.max.getUTCFullYear(), calendar.max.getUTCMonth(), 0)
                                );

                                calendar.months.pop();
                            };
                            d.weeks = service.getWeeksInMonth(d);

                            return d;
                        }

                    calendar.min = getMin(service
                        .getFirstOfMonth(date)
                    );

                    date = service.getUTCDate(
                        date.getUTCFullYear(),
                        date.getUTCMonth() + preload - 1,
                        date.getUTCDate()
                    );

                    calendar.max = getMax(service
                        .getLastOfMonth(date)
                    );

                    return calendar;
                },
                createMonths: function(date, count) {

                    var months = [];
                    for (var i = 0; i < count; i++) {

                        var monthDate =
                            service.getUTCDate(date.getUTCFullYear(), date.getUTCMonth() + i, 1);

                        months.push(service.createMonth(monthDate));
                    }

                    return months;
                },
                createMonth: function(date) {

                    var cells = [],
                        month = date.getUTCMonth(),
                        monthDate = service.getUTCDate(
                            date.getUTCFullYear(), month, 1),
                        todayDate = new Date().toDateString(),
                        lastDate = service.getLastOfMonth(date).getDate(),
                        firstDay = service.getFirstDayOfMonth(date),
                        lastDay = service.getLastDayOfMonth(date);

                    for (var i = -(firstDay === 0 ? 7 : firstDay) + 2;
                        i < service.getDaysInMonth(monthDate) + (8 - lastDay);
                        i++) {

                        var dayDate =
                            service.getUTCDate(monthDate.getUTCFullYear(), monthDate.getUTCMonth(), i),
                            dayOfMonth = dayDate.getDate(),
                            dayOfWeek = dayDate.getDay();

                        if (dayDate.getUTCMonth() === monthDate.getUTCMonth()) {

                            var isFirstWeek = service.isFirstWeekOfMonth(dayDate),
                                isLastWeek = service.isLastWeekOfMonth(dayDate);

                            cells.push({
                                date: dayDate,
                                isFirst: dayOfMonth === 1,
                                isFirstDay: dayOfWeek === 1,
                                isFirstWeek: isFirstWeek,
                                isLast: dayOfMonth === lastDate,
                                isLastDay: dayOfWeek === 0,
                                isLastWeek: isLastWeek,
                                isWeekend: dayOfWeek === 6 || dayOfWeek === 0,
                                isToday: dayDate.toDateString() == todayDate,
                                isFirstSunday: isFirstWeek && dayOfWeek === 0,
                                isFirstMonday: isFirstWeek && dayOfWeek === 1,
                                isLastSunday: isLastWeek && dayOfWeek === 0,
                                isLastMonday: isLastWeek && dayOfWeek === 1,
                                is: function (d) {
                                    
                                    return this.date.getFullYear() === d.getFullYear()
                                        && this.date.getMonth() === d.getMonth()
                                        && this.date.getDate() === d.getDate();
                                }
                            });

                        } else {
                            cells.push({});
                        }
                    }

                    return {
                        date: monthDate,
                        cells: cells,
                        weeks: service.getWeeksInMonth(monthDate)
                    };
                },
                getFirstOfMonth: function(date) {

                    return service.getUTCDate(date.getUTCFullYear(), date.getUTCMonth(), 1);
                },
                getFirstDayOfMonth: function(date) {

                    return service.wrapWeekDay(service.getFirstOfMonth(date).getDay());
                },
                getLastOfMonth: function(date) {

                    return service.getUTCDate(date.getUTCFullYear(), date.getUTCMonth()+1, 0);
                },
                getLastDayOfMonth: function(date) {

                    return service.wrapWeekDay(service.getLastOfMonth(date).getDay());
                },
                getDaysInMonth: function(date) {

                    return service.getLastOfMonth(date).getUTCDate();
                },
                addDays: function(date, days) {
                    return service.getUTCDate(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate() + days);
                },
                isFirstWeekOfMonth: function (date) {
                    return date.getUTCMonth() !==
                        service.addDays(date, -7).getUTCMonth();
                },
                isLastWeekOfMonth: function(date) {
                    return date.getUTCMonth() !==
                        service.addDays(date, 7).getUTCMonth();
                },
                getWeeksInMonth: function (d) {
                    return Math.ceil(
                        (service.wrapWeekDay(service.getFirstDayOfMonth(d) - 1)
                            + service.getDaysInMonth(d) + 1) / 7
                    );
                },
                getUTCDate: function (y, m, d) {
                    var date = new Date(y, m, d);
                    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), 0, 0, 0));
                },
                wrapWeekDay: function (value) {
                    return value < 0
                        ? service.wrapWeekDay(value + 7)
                        : value > 6
                        ? service.wrapWeekDay(value - 7)
                        : value;
                }
            };

            return service;
        }
    ]);