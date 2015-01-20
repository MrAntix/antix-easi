'use strict';

angular.module('antix.easi.examiners', [
        'antix.easi.examiners.api',
        'antix.easi.examiners.index',
        'antix.easi.examiners.select',
        'antix.easi.examiners.create',
        'antix.easi.examiners.edit'
    ])
    .config([
        '$stateProvider',
        function(
            $stateProvider
        ) {
            $stateProvider
                .state('examiners-index', {
                    url: '/examiners/',
                    templateUrl: '/client/examiners/index/examiners-index.cshtml',
                    controller: 'AntixEASIExaminersIndexController'
                })
                .state('examiners-create', {
                    url: '/examiners/create',
                    templateUrl: '/client/examiners/create/examiners-create.cshtml',
                    controller: 'AntixEASIExaminersCreateController'
                })
                .state('examiners-edit', {
                    url: '/examiners/{id}/edit',
                    templateUrl: '/client/examiners/edit/examiners-edit.cshtml',
                    controller: 'AntixEASIExaminersEditController'
                });

        }
    ])
    .constant('ExaminerEvents', {
        Created: 'examiner-event:created',
        Updated: 'examiner-event:updated',
        Deleted: 'examiner-event:deleted'
    })
    .filter('examinerName', [
        function() {
            return function(examiner) {
                return examiner.name + ' (' + examiner.identifier + ')';
            };
        }
    ]);