let editorForm = document.getElementById("editform");
let qEditor = quill;

window.onload = function () {
    let articleContent = document.getElementById("articlecontent").value;
    qEditor.root.innerHTML = articleContent;
};

function getQuillContent() {
    let text = qEditor.root.textContent;
    return text;
}

editorForm.onsubmit = function () {
    $("content").replaceWith(getQuillContent());
    /*
    let content = document.getElementById("content");
    content.value = getQuillContent();*/
}
