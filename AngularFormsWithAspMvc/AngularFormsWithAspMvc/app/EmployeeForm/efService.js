angularFormsApp.factory('efService',
    function () {
        return {
            employee: {
                fullName: "Катаев Михаил",
                notes: "Лучший работник месяца.",
                department: "Администратор",
                perkcar: true,
                perkStock: false,
                perkSixWeeks: true,
                payrollType: "none"
            }
        }
});