$(document).ready(() => {
    $("#AddOrganizationModalFormSaveBtn").on("click", () => {
        SaveOrganization();
    })
});

function SaveOrganization() {
    SubmitForm({
        formElement: "#AddOrganizationModalForm",
        url: "/Organization/CreateOrganization",
        successCallback: () => {
            alert("Data saved successfully");
        }
    })
}