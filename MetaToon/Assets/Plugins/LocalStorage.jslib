mergeInto(LibraryManager.library, {

    GetLocalStorageValue: function (key){

        var result = window.localStorage.getItem(UTF8ToString(key));
        console.log(result)

        var bufferSize = lengthBytesUTF8(result) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(result, buffer, bufferSize);
        return buffer;
    },
});