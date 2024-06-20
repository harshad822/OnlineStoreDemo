(function () {
  "use strict";

  /**
   * Easy selector helper function
   */
  const select = (el, all = false) => {
    el = el.trim();
    if (all) {
      return [...document.querySelectorAll(el)];
    } else {
      return document.querySelector(el);
    }
  };

  /**
   * Easy event listener function
   */
  const on = (type, el, listener, all = false) => {
    if (all) {
      select(el, all).forEach((e) => e.addEventListener(type, listener));
    } else {
      select(el, all).addEventListener(type, listener);
    }
  };

  /**
   * Easy on scroll event listener
   */
  const onscroll = (el, listener) => {
    el.addEventListener("scroll", listener);
  };

  /**
   * Navbar links active state on scroll
   */
  let navbarlinks = select("#navbar .scrollto", true);
  const navbarlinksActive = () => {
    let position = window.scrollY + 200;
    navbarlinks.forEach((navbarlink) => {
      if (!navbarlink.hash) return;
      let section = select(navbarlink.hash);
      if (!section) return;
      if (position >= section.offsetTop && position <= section.offsetTop + section.offsetHeight) {
        navbarlink.classList.add("active");
      } else {
        navbarlink.classList.remove("active");
      }
    });
  };
  window.addEventListener("load", navbarlinksActive);
  onscroll(document, navbarlinksActive);

  /**
   * Scrolls to an element with header offset
   */
  const scrollto = (el) => {
    let header = select("#header");
    let offset = header.offsetHeight;

    if (!header.classList.contains("header-scrolled")) {
      offset -= 10;
    }

    let elementPos = select(el).offsetTop;
    window.scrollTo({
      top: elementPos - offset,
      behavior: "smooth",
    });
  };

  /**
   * Toggle .header-scrolled class to #header when page is scrolled
   */
  let selectHeader = select("#header");
  if (selectHeader) {
    const headerScrolled = () => {
      if (window.scrollY > 100) {
        selectHeader.classList.add("header-scrolled");
      } else {
        selectHeader.classList.remove("header-scrolled");
      }
    };
    window.addEventListener("load", headerScrolled);
    onscroll(document, headerScrolled);
  }

  /**
   * Back to top button
   */
  let backtotop = select(".back-to-top");
  if (backtotop) {
    const toggleBacktotop = () => {
      if (window.scrollY > 100) {
        backtotop.classList.add("active");
      } else {
        backtotop.classList.remove("active");
      }
    };
    window.addEventListener("load", toggleBacktotop);
    onscroll(document, toggleBacktotop);
  }

  /**
   * Mobile nav toggle
   */
    on("click", ".mobile-nav-toggle", function (e) {
        $(".cls-mobile-nav").removeClass("d-none");
      select(".cls-mobile-nav").classList.toggle("navbar-mobile");
    this.classList.toggle("bi-list");
        this.classList.toggle("bi-x");

        function o() {
            var t = $(".sub-menu-toggle");
            $.each(t, function () {
                $(this).outerHeight($(this).siblings("a").outerHeight()), $(this).css("line-height", $(this).siblings("a").outerHeight() + "px");
            });
        }

        var n,
            a = $(".nav-menu");

        var testvar = e;

        a.toggleClass("active"),
            (function () {
                var t = 0;
                if (a.hasClass("active")) {
                    var i = a.children("li");
                    $.each(i, function () {
                        t += $(this).outerHeight();
                    });
                }
                a.css("height", t);
            })();

        $(".sub-menu-toggle").on("click", function () {
            var t, i;
            $(this).siblings(".sub-menu").toggleClass("active"),
                o(),
                (t = a.outerHeight()),
                (i = $(".sub-menu")),
                $.each(i, function () {
                    $(this).outerHeight(t);
                });
            if ($(".sub-menu.menu").hasClass('active'))
            {
                $(this).closest(".nav-menu.menu.active").css({ 'top': '0px' });
            }
            else {
                $(this).closest(".nav-menu.menu").css({ 'top': '55px' });
            }

            
            
        });

        $(".close").on("click", function () {
            $(this).parent(".sub-menu").toggleClass("active");
        });
  });

  /**
   * Mobile nav dropdowns activate
   */
  on(
    "click",
    ".navbar .dropdown > a",
    function (e) {
        if (select(".cls-mobile-nav").classList.contains("navbar-mobile")) {
        e.preventDefault();
        this.nextElementSibling.classList.toggle("dropdown-active");
      }
    },
    true
  );

  /**
   * Scrool with ofset on links with a class name .scrollto
   */
  on(
    "click",
    ".scrollto",
    function (e) {
      if (select(this.hash)) {
        e.preventDefault();

          let navbar = select(".cls-mobile-nav");
        if (navbar.classList.contains("navbar-mobile")) {
          navbar.classList.remove("navbar-mobile");
          let navbarToggle = select(".mobile-nav-toggle");
          navbarToggle.classList.toggle("bi-list");
          navbarToggle.classList.toggle("bi-x");
        }
        scrollto(this.hash);
      }
    },
    true
  );

  /**
   * Scroll with ofset on page load with hash links in the url
   */
  window.addEventListener("load", () => {
    if (window.location.hash) {
      if (select(window.location.hash)) {
        scrollto(window.location.hash);
      }
    }
  });

  /**
   * Animation on scroll
   */
  function aos_init() {
    AOS.init({
      duration: 1000,
      easing: "ease-in-out",
      once: true,
      mirror: false,
    });
  }
  window.addEventListener("load", () => {
      aos_init();
  });
})();
function bckClk() {
    $("#mblMenu").css({ 'top': '55px' });
    return true;
}
