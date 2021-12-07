import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  template: ` <navbar></navbar>
    <main role="main" class="container pt-4">
      <router-outlet></router-outlet>
      <hr class="mt-1" />
    </main>

    <footer class="container footer text-muted">
      <p>&copy; The Fun-Company.io 2021 - Terence Frade Project</p>
    </footer>`,
  styles: [],
})
export class AppComponent {
  title = "The Fun Company";
}
