import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})



export class AppComponent  {
  title = 'App Product Manager ';

  activeTab: string = 'manages'; // Set the default active tab

  setActiveTab(tab: string): void {
    this.activeTab = tab;
  }


}
