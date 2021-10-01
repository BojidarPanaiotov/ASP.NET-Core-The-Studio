//const { start } = require("@popperjs/core");

const apiRoutes = {
    api: 'api/electronic-books',
    bookRarity: 'book-rarity',
    books: 'books',
    filtered: 'filtered-by-search-term-gener-category-rarity',
}

let rarityCheckboxes = document.getElementsByClassName('book_rarity');
let generCheckboxes = document.getElementsByClassName('book_gener');
let searchBar = document.getElementById('searchBar');
let selectElement = document.getElementById('book-sorting');
let bookWrapper = document.getElementById('all_electronic_books');
let pagination = document.getElementById('pagination');
let queryString = '';

//Search Bar
searchBar.addEventListener('keyup', (event) => {
    if (searchBar.value.length > 2) {
        let currentPageEl = document.getElementById('currentPage');
        currentPageEl.value = 1

        queryString = buildQueryString(searchBar, rarityCheckboxes, generCheckboxes, 1);
        replaceWithQueryListBooks(bookWrapper, queryString);
        window.location.hash = queryString;
    }
})

//Checkboxes
document.getElementById('filtering_searching_managing').addEventListener('change', () => {
    let currentPageEl = document.getElementById('currentPage');
    currentPageEl.value = 1

    queryString = buildQueryString(searchBar, rarityCheckboxes, generCheckboxes, 1);
    replaceWithQueryListBooks(bookWrapper, queryString);
    window.location.hash = queryString;
})

//Pagination
document.getElementById('pagination').addEventListener('click', (e) => {
    if (e.target.tagName == 'I') {
        let currentPageEl = document.getElementById('currentPage');

        if (e.target.id == "maxPageBtn") {
            currentPageEl.value = document.getElementById('maxPage').value;
        } else if (e.target.id == "minPageBtn") {
            currentPageEl.value = document.getElementById('minPage').value;
        }

        queryString = buildQueryString(searchBar, rarityCheckboxes, generCheckboxes, currentPageEl.value);
        replaceWithQueryListBooks(bookWrapper, queryString);
        window.location.hash = queryString;

        return;

    } else if (e.target.tagName != 'A') {
        return;
    }

    let currentPageEl = document.getElementById('currentPage');
    currentPageEl.value = e.target.textContent;

    queryString = buildQueryString(searchBar, rarityCheckboxes, generCheckboxes, currentPageEl.value);
    replaceWithQueryListBooks(bookWrapper, queryString);
    window.location.hash = queryString;
})

function replaceWithQueryListBooks(wrapper, queryString) {
    let apiRout = `${apiRoutes.api}/${apiRoutes.filtered}?${queryString}`;
    console.log(apiRout);
    fetch(apiRout)
        .then(response => response.json())
        .then(bookData => {
            let booksHtml = '';
            bookData.books.forEach(book => {
                booksHtml +=
                    `<div class="card ml-4 mb-4 electronic_book_product" style="width: 13rem;">
            <img class="card-img-top" src="https://m.media-amazon.com/images/I/41gS+bWw3XL.jpg" alt="Card image cap">
            <div class="card-body">
                <h5 class="card-title text-truncate">${book.title}</h5>
                <p class="card-text text-truncate">Description: ${book.description}</p>
                <p class="card-text text-truncate">Author: ${book.author}</p>
                <p class="card-text">CopySold: ${book.copySold}</p>
                <p class="card-text">Rarity: ${book.bookRarityName}</p>
                <p class="card-text text-truncate">Geners: ${(book.geners.map(x => x.name)).join()}</p>
                <a href="#" class="btn btn-primary mb-3">Buy for ${book.price} BGN</a>
            </div>
         </div>`
            });

            wrapper.innerHTML = booksHtml;
            pagination.innerHTML = buildPaginationHtml(bookData.totalPages, Number(document.getElementById('currentPage').value));
            window.scrollTo(0, 0);
        });
}

function buildPaginationHtml(bookCount, currentPage) {
    let previousPage = currentPage - 1;

    if (previousPage == 0) {
        previousPage = 1;
    }

    let maxPage = Math.ceil(bookCount / 8);

    let startPage = currentPage - 5;

    if (startPage < 0) {
        startPage = 1;
    } else if (startPage + 4 > maxPage) {
        startPage = maxPage - 4;
    } else {
        startPage = currentPage;
    }

    let endPage = 0;

    if (startPage + 4 > maxPage) {
        endPage = maxPage;
    } else {
        endPage = startPage + 4;
    }

    let paginationHtml = `<input id="currentPage" hidden value="${currentPage}"/>
                          <input id="maxPage" hidden value="${maxPage}" />
                          <input id="minPage" hidden value="1" />`;

    if (currentPage != 1) {
        paginationHtml +=
            '<a><i class="fa fa-angle-double-left" id="minPageBtn"></i></a>';
    }

    for (let i = previousPage; i <= endPage; i++) {
        if (i == currentPage) {
            paginationHtml += `<a class="current-page page-number">${i}</a>`;
        } else {
            paginationHtml += `<a class="page-number">${i}</a>`;
        }
    }

    if (!(currentPage == maxPage) && currentPage != 0 && maxPage != 0) {
        paginationHtml += '<a><i class="fa fa-angle-double-right" id="maxPageBtn"></i></a>';
    }

    return paginationHtml;
}

function getQueryStringFromCheckboxes(checkboxCollection, checkboxType) {
    var result = '';

    for (let checkbox of checkboxCollection) {
        if (checkbox.checked) {
            result += `${checkboxType}=${checkbox.name.trimEnd()}&`;
        }
    }

    return result;
}

function getQueryFromSearchTerm(searchBar) {
    let result = '';

    if (searchBar.value.length > 2) {
        result += `${searchBar.getAttribute("name")}=${searchBar.value.toLowerCase()}&`;
    }

    return result;
}

function getQueryStringFromSortingList(selectElement) {
    let selectedOption = selectElement.options[selectElement.selectedIndex].value;

    let result = '';

    result += `sorting=${selectedOption}&`;

    return result;
}

function getQueryStringFromPagination(currentPage) {
    return `currentPage=${document.getElementById('currentPage').value}`;
}

function buildQueryString(searchBar, rarityCheckboxes, generCheckboxes, currentPage) {
    let result = '';

    result += getQueryFromSearchTerm(searchBar);
    result += getQueryStringFromCheckboxes(rarityCheckboxes, 'rarities');
    result += getQueryStringFromCheckboxes(generCheckboxes, 'geners');
    result += getQueryStringFromSortingList(selectElement);
    result += getQueryStringFromPagination(currentPage);

    return result;
}