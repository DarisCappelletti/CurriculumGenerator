interface IconProps {
  className?: string;
  size?: number;
}

function createIcon(pathData: string) {
  const Icon = ({ className, size = 20 }: IconProps) => (
    <svg
      className={className}
      width={size}
      height={size}
      viewBox="0 0 20 20"
      fill="none"
      stroke="currentColor"
      strokeWidth="1.5"
      strokeLinecap="round"
      strokeLinejoin="round"
    >
      <path d={pathData} />
    </svg>
  );
  Icon.displayName = 'Icon';
  return Icon;
}

export const IconPerson = createIcon(
  'M10 10a4 4 0 1 0 0-8 4 4 0 0 0 0 8ZM2 18c0-4 3.6-7 8-7s8 3 8 7'
);

export const IconEnvelope = createIcon(
  'M2 5l8 5 8-5M2 5v10a1 1 0 0 0 1 1h14a1 1 0 0 0 1-1V5a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1Z'
);

export const IconGraduation = createIcon(
  'M2 8l8-4 8 4-8 4-8-4ZM6 11v3c0 1 1.5 2 4 2s4-1 4-2v-3M18 8v6'
);

export const IconTag = createIcon(
  'M3 3h5l7 7-5 5-7-7V3ZM7 7h.01'
);

export const IconBriefcase = createIcon(
  'M3 7h14v9a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V7ZM7 7V5a1 1 0 0 1 1-1h4a1 1 0 0 1 1 1v2M3 7h14'
);

export const IconDocument = createIcon(
  'M4 3a1 1 0 0 1 1-1h6l5 5v9a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1V3ZM11 2v5h5M7 11h6M7 14h4'
);

export const IconCode = createIcon(
  'M7 5L3 10l4 5M13 5l4 5-4 5'
);

export const IconCamera = createIcon(
  'M3 6a1 1 0 0 1 1-1h1.5l1-2h7l1 2H16a1 1 0 0 1 1 1v9a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V6ZM10 14a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z'
);

export const IconUpload = createIcon(
  'M10 14V3M6 6l4-4 4 4M3 14v2a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1v-2'
);

export const IconCheck = createIcon(
  'M4 10l4 4 8-8'
);

export const IconError = createIcon(
  'M10 3a7 7 0 1 0 0 14 7 7 0 0 0 0-14ZM10 7v4M10 13h.01'
);