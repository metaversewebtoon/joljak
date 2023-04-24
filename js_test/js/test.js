// fetch("http://34.145.65.5:46351/file")
//   .then((response) => {
//     if (response.ok) {
//       return response.blob(); // if response is ok, get blob data
//     }
//     throw new Error("Network response was not ok");
//   })
//   .then((data) => {
//     console.log(data);
//     data.forEach((image) => {
//       const imageUrl = URL.createObjectURL(image); // create an object URL from the blob data
//       const img = document.createElement("img"); // create an img element
//       img.src = imageUrl; // set the img source to the object URL

//       // Add the image element to the image container
//       const imageContainer = document.getElementById("image-container");
//       imageContainer.appendChild(img);
//     });
//   })
//   .catch((error) => console.error("Error fetching :", error));
import JSZip from "./jszip";

fetch("http://34.145.65.5:46351/file")
  .then((response) => {
    if (response.ok) {
      return response.arrayBuffer(); // get binary data
    }
    throw new Error("Network response was not ok");
  })
  .then((data) => {
    return JSZip.loadAsync(data); // load the binary data as a ZIP file
  })
  .then((zip) => {
    const imageNames = Object.keys(zip.files).filter((name) =>
      name.match(/\.(jpg|jpeg|png|gif)$/i)
    );

    return Promise.all(
      imageNames.map((name) => {
        return zip.file(name).async("blob"); // extract each image as a blob
      })
    );
  })
  .then((blobs) => {
    blobs.forEach((blob) => {
      const imageUrl = URL.createObjectURL(blob); // create an object URL from the blob data
      const img = document.createElement("img"); // create an img element
      img.src = imageUrl; // set the img source to the object URL

      // Add the image element to the image container
      const imageContainer = document.getElementById("image-container");
      imageContainer.appendChild(img);
    });
  })
  .catch((error) => console.error("Error fetching:", error));
