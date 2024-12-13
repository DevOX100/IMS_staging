<script type="text/javascript">
    function validateFileUpload(fileInput) {
        // Get the file
        var file = fileInput.files[0];

    // Check if a file is selected
    if (!file) {
        alert('Please select an image to upload.');
    return false;
        }

    // Validate file type (JPG/JPEG)
    var allowedTypes = ['image/jpeg', 'image/jpg'];
    if (!allowedTypes.includes(file.type)) {
        alert('Please upload an image in JPG format only.');
    fileInput.value = ''; // Clear the file input
    return false;
        }

    // Validate file size (1MB = 1048576 bytes)
    var maxSizeInBytes = 1048576; // 1MB
        if (file.size > maxSizeInBytes) {
        alert('File size exceeds 1MB. Please choose a smaller image.');
    fileInput.value = ''; // Clear the file input
    return false;
        }

    return true;
    }
</script>