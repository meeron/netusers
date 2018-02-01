export function mapGroup(group) {
  group.deleting = false;
  return group;  
}

export function mapGroups(groups) {
  return groups.map(g => mapGroup(g));
}