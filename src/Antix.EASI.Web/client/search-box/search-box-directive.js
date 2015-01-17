'use strict';

angular.module('antix.easi.searchBox', [
])
    .constant('SearchBoxEvents', {
        Search: 'search-box-event:search'
    })
    .directive(
        'searchBox',
        [
            '$log',
            'SearchBoxEvents',
            function(
                $log,
                SearchBoxEvents) {

                $log.debug('searchBox init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'search-box/search-box.cshtml',
                    link:function($scope) {

                        $scope.search = function(text) {
                            $log.debug('searchBox search(\''+text+'\')');

                            $scope.$emit(SearchBoxEvents.Search, { text: text });

                        };
                    }
                };
            }
        ]);
