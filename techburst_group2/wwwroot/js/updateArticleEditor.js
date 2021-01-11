let editorForm = document.getElementById("editform");
let qEditor = quill;

window.onload = function () {
    let articleContent = document.getElementById("articlecontent").value;
    qEditor.root.innerHTML = articleContent;
};

var editors = {};
editors[uEditor] = qEditor;

function getQuillContent() {
    let q = editors[uEditor];
    let text = q.root.innerHTML;//qEditor.root.textContent;
    return text;
}

editorForm.onsubmit = function () {
    $("#content").html(getQuillContent());
}
