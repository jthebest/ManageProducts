import { Component, OnInit } from '@angular/core';
import { Manage } from '../../models/manage.model';
import { ManageService } from '../../services/manage.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-Manage-detail',
  templateUrl: './manage-detail.component.html',
  standalone: true,
  styleUrls: ['./manage-detail.component.css'],
  imports: [  FormsModule ]
})
export class ManageDetailComponent implements OnInit {
  currentManage: Manage = { name: '' };
  isNew = true;

  constructor(private ManageService: ManageService) { }

  ngOnInit(): void {
    // Implement initialization logic if editing existing Manage
  }

  saveManage(): void {
    if (this.isNew) {
      this.createManage();
    } else {
      this.updateManage();
    }
  }

  createManage(): void {
    this.ManageService.createManage(this.currentManage)
      .subscribe(() => {
        // Handle success
      });
  }

  updateManage(): void {
    // Implement update logic
  }
}
