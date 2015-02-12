'use strict';

angular.module('antix.easi.examinations.api', [
        'ngResource'
    ])
    .factory(
        'ExaminationsApi',
        [
            '$resource',
            function(
                $resource) {

                return $resource('/api/examinations/', {}, {
                    search: {
                        method: 'GET',
                        url: '/api/examinations/'
                    },
                    create: {
                        method: 'POST',
                        url: '/api/examinations/'
                    },
                    read: {
                        method: 'GET',
                        url: '/api/examinations/:id'
                    },
                    update: {
                        method: 'PUT',
                        url: '/api/examinations/:id',
                        params: { id: '@id' }
                    },
                    'delete': {
                        method: 'DELETE',
                        url: '/api/examinations/:id'
                    }
                });
            }
        ]);
