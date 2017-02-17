import { InMemoryDbService } from 'angular-in-memory-web-api';

import { createTestData } from './test-data';

export class InMemoryDataService implements InMemoryDbService {
    createDb() {
        return { data: createTestData() };
    }
}