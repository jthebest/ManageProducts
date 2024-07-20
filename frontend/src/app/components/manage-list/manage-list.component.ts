import { Component, OnInit } from '@angular/core';
import { Manage } from '../../models/manage.model';
import { ManageService } from '../../services/manage.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-Manage-list',
  templateUrl: './manage-list.component.html',
  styleUrls: ['./manage-list.component.css'],
  standalone: true,
  imports: [  CommonModule ]
})
export class ManageListComponent implements OnInit {
  manages: Manage[] = [];

  constructor(private ManageService: ManageService) { }

  ngOnInit(): void {
    this.getManages();
  }

  getManages(): void {
    this.ManageService.getManages()
      .subscribe(manages => this.manages = manages);
  }
}
