String.prototype.SubString = function (indexStart, indexEnd) {
    var string = this;
    if (indexStart >= string.length || indexStart < 0) {
        alert('Invalid Start Index');
        return;
    }
    if (indexEnd >= string.length || indexEnd < indexStart) {
        alert('Invalid End Index');
        return;
    }
    var final = "";
    for (i = indexStart; i < indexEnd; i++) {
        final += string.charAt(i);
    }
    return final;
};