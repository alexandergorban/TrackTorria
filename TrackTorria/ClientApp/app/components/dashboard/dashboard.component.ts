import { Component, ViewChild, OnInit, HostListener } from '@angular/core';
import { MatSidenav } from "@angular/material";

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.less']
})
export class DashboardComponent {
  mode = 'side';
  opened = true;

  @ViewChild('sidenav') sidenav: MatSidenav;
  navMode = 'side';

  constructor() {

  }

  ngOnInit() {
    if (window.innerWidth <= 600) {
      this.navMode = 'over';
      this.opened = false;
    }
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    if (event.target.innerWidth <= 600) {
      this.navMode = 'over';
      this.sidenav.close();
    }
    if (event.target.innerWidth > 600) {
      this.navMode = 'side';
      this.sidenav.open();
    }
  }
}
