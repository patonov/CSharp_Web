
function attachEvents() {

    document.querySelector("#btnLoadPosts").addEventListener("click", loadSinglePost);

}

async function loadSinglePost() {
        let comment = document.querySelector("#post");
        comment.innerHTML = "";

        const item = document.createElement("li");
        item.textContent = "Tralalaaa";

        comment.appendChild(item);
}

attachEvents();

