angularFormsApp.controller('efController',
    function EmployeeFormController($scope, efService) {
        $scope.employee = efService.employee;

        $scope.departments = [
                "Инжинер",
                "Маркетинг",
                "Финансовый",
                "Администратор",
        ];
    }
);