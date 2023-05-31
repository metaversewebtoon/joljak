fetch("http://34.145.65.5:46351/file/1", {})
  .then((response) => {
    if (response.ok) {
      return response.blob(); // if response is ok, get blob data
    }
    throw new Error("Network response was not ok");
  })
  .then((data) => {
    const imageUrl = URL.createObjectURL(data); // create an object URL from the blob data
    const img = document.createElement("img"); // create an img element
    img.src = imageUrl; // set the img source to the object URL
    img.width = 600;
    img.height = 3000;

    // Add the image element to the image container
    const imageContainer = document.getElementById("image-container");
    imageContainer.appendChild(img);
  })
  .catch((error) => console.error("Error fetching image:", error));

/*
  fetch('http://34.145.65.5:46351/file', {
  })
  .then(response => {
    if (response.ok) {
      return response.blob(); // if response is ok, get blob data
    }
    throw new Error('Network response was not ok');
  })
  .then(data => {
    data.forEach(image => {
      const imageUrl = URL.createObjectURL(data); // create an object URL from the blob data
      const img = document.createElement('img'); // create an img element
      img.src = imageUrl; // set the img source to the object URL

      // Add the image element to the image container
      const imageContainer = document.getElementById('image-container');
      imageContainer.appendChild(img);
    });
  })
  .catch(error => console.error('Error fetching image:', error));
  */
