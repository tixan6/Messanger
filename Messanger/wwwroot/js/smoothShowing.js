$("DOMContentLoaded").ready(function () {  
    const nodeListField = document.querySelectorAll(".field-validation-error");
    

    for (var i in nodeListField) {
        nodeListField[i].style.opacity = "1";
    }

    
});
