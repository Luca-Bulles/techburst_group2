let editorForm = document.getElementById("editform");

window.onload = function () {
    let content = document.getElementById("articlecontent").value;
    let qEditor = quill;
    qEditor.root.innerHTML = content;
};

function getQuillContent() {
    let qEditor = editors[editor];
    let text = qEditor.root.textContent;
    return text;
}

editorForm.onsubmit = function () {
    let content = document.getElementById("content");
    content.value = getQuillContent();
}
