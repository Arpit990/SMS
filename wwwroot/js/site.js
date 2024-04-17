function SubmitForm({
    formElement,
    url,
    beforeSendCallback,
    successCallback,
    errorCallback,
    completeCallback,
    timeoutDuration = 5000
}) {
    // Serialize form data
    var formData = $(formElement).serialize();

    // Make AJAX request
    $.ajax({
        type: "POST",
        url: url,
        data: formData,
        beforeSend: function (xhr) {
            // Execute beforeSendCallback if provided
            if (beforeSendCallback && typeof beforeSendCallback === 'function') {
                beforeSendCallback(xhr);
            }
        },
        success: function (response) {
            if (successCallback && typeof successCallback === 'function') {
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (errorCallback && typeof errorCallback === 'function') {
                errorCallback(xhr, status, error);
            }
        },
        complete: function (xhr, status) {
            // Execute completeCallback if provided
            if (completeCallback && typeof completeCallback === 'function') {
                completeCallback(xhr, status);
            }
        },
        timeout: timeoutDuration || 0  // Set AJAX timeout duration (0 means no timeout)
    });
}



function showToast({
    title,
    message
}) {
    // Select elements
    const container = document.getElementById('toastStackNotification');
    const targetElement = document.querySelector('[data-kt-docs-toast="stack"]'); // Use CSS class or HTML attr to avoid duplicating ids

    // Remove base element markup
    targetElement.parentNode.removeChild(targetElement);

    $("#toastTitle").html(title);
    $("#toastMessage").html(message);

    // Handle button click
    button.addEventListener('click', e => {
        e.preventDefault();

        // Create new toast element
        const newToast = targetElement.cloneNode(true);
        container.append(newToast);

        const toast = bootstrap.Toast.getOrCreateInstance(newToast);

        toast.show();
    });
}