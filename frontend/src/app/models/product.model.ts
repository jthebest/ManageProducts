// product.model.ts
import { Manage } from './manage.model';

export interface Product {
  id?: number | null;
  title: string;
  content: string;
  update_time: string;
  archived: boolean;
  manage?: Manage | null | undefined; // Ensure Manage is properly typed
}
