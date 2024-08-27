window.onload = function() {
    const image = document.getElementById('sliding-image');
    console.log('JavaScript is running'); // Debugging check

    setTimeout(() => {
        image.style.left = '0'; // Slide the image into view
        console.log('Image sliding in'); // Debugging check
    }, 500); // Adjust the delay (in milliseconds) as needed
};
