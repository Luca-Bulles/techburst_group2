let editorForm = document.getElementById("editform");
let qEditor = quill;

window.onload = function () {
    let articleContent = document.getElementById("articlecontent").value;
    qEditor.root.innerHTML = articleContent;
};

function getQuillContent() {
    let text = qEditor.root.innerHTML;//qEditor.root.textContent;
    return text;
}

editorForm.onsubmit = function () {
    var content = document.querySelector('input[name=content]');
    content.value = getQuillText();
}
