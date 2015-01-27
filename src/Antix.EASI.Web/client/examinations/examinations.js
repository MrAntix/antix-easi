'use strict';

angular.module('antix.easi.examinations', [
        'antix.easi.examinations.api',
        'antix.easi.examinations.index',
        'antix.easi.examinations.select',
        'antix.easi.examinations.create',
        'antix.easi.examinations.edit'
    ])
    .config([
        '$stateProvider',
        function(
            $stateProvider
        ) {
            $stateProvider
                .state('examinations-index', {
                    url: '/examinations/',
                    templateUrl: '/client/examinations/index/examinations-index.cshtml',
                    controller: 'AntixEASIExaminationsIndexController'
                })
                .state('examinations-create', {
                    url: '/examinations/create',
                    templateUrl: '/client/examinations/create/examinations-create.cshtml',
                    controller: 'AntixEASIExaminationsCreateController'
                })
                .state('examinations-edit', {
                    url: '/examinations/{id}/edit',
                    templateUrl: '/client/examinations/edit/examinations-edit.cshtml',
                    controller: 'AntixEASIExaminationsEditController'
                });

        }
    ])
    .constant('ExaminationEvents', {
        Created: 'examination-event:created',
        Updated: 'examination-event:updated',
        Deleted: 'examination-event:deleted'
    })
    .filter('examinationTitle', [
        function () {
            return function (examination) {
                return examination.patient.name + ' (' + examination.takenOn + ')';
            };
        }
    ]);