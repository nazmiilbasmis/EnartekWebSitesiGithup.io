// Elemanları Seç
const searchForm = document.querySelector(".search-form");
const navbar = document.querySelector(".navbar");
const searchBtn = document.querySelector("#search-btn");
const menuBtn = document.querySelector("#menu-btn");
const searchInput = document.getElementById("search-box");

// Genel toggle işlevi
function toggleElement(btn, element) {
  element.classList.toggle("active");

  const handleClickOutside = (e) => {
    if (!btn.contains(e.target) && !element.contains(e.target)) {
      element.classList.remove("active");
      document.removeEventListener("click", handleClickOutside);
    }
  };

  document.addEventListener("click", handleClickOutside);
}

// Arama butonu
searchBtn.addEventListener("click", (e) => {
  e.stopPropagation();
  toggleElement(searchBtn, searchForm);
  navbar.classList.remove("active"); // Menü kapansın
});

// Menü butonu
menuBtn.addEventListener("click", (e) => {
  e.stopPropagation();
  toggleElement(menuBtn, navbar);
  searchForm.classList.remove("active"); // 🔁 Arama kutusunu kapat
});

// Arama işlevi (ENTER ile arama)
searchInput.addEventListener("keypress", function (e) {
  if (e.key === "Enter") {
    e.preventDefault();
    const keyword = searchInput.value.trim().toLowerCase();
    let found = false;

    const elements = document.querySelectorAll("body *:not(nav):not(nav *)");

    elements.forEach(el => {
      if (
        el.childNodes.length === 1 &&
        el.childNodes[0].nodeType === Node.TEXT_NODE &&
        el.textContent.trim().toLowerCase().includes(keyword)
      ) {
        if (!found) {
          el.scrollIntoView({ behavior: "smooth", block: "center" });
          found = true;
        }
      }
    });

    if (!found) {
      alert("Sonuç bulunamadı.");
    }

    // Arama sonrası formu kapat ve input'u temizle
    setTimeout(() => {
      searchForm.classList.remove("active");
      searchInput.value = "";
    }, 100);
  }
});

// Menü öğelerine tıklanırsa menü kapansın
const menuItems = document.querySelectorAll(".navbar a");
menuItems.forEach(item => {
  item.addEventListener("click", () => {
    navbar.classList.remove("active");
  });
});