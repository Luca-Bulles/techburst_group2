let editorForm = document.getElementById("editform");

window.onload = function () {
    let content = document.getElementById("articleContent").value;
    let qEditor = quill;
    qEditor.root.innerHTML = content;
};

function getQuillContent() {
    let qEditor = editors[editor];
    let text = qEditor.root.textContent;
    return text;
}

editorForm.onsubmit = function () {
    let content = document.querySelector('input[name=content]');
    content.value = getQuillContent();
}
